﻿using ControlePortaria.Models.Enums;
using ControlePortaria.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePortaria.Models
{
    public class Portaria
    {
        public Portaria()
        {
            
        }
        public Portaria(int pessoaId,int carroId,DateTime horaSaida,string destino)
        {
            PessoaId = pessoaId;
            CarroId = carroId;
            HorarioSaida = horaSaida;
            Destino = destino;
            PortariaStatus = PortariaStatus.PortariaAberta;
        }

        [Key]
        public int PortariaId { get; set; }
        [Required]
        public int PessoaId { get; set; }
        [Required]
        public int CarroId { get; set; }

        [Required]
        [Display(Name ="Data e horario de saida.")]
        public DateTime HorarioSaida { get; set; }

        [Display(Name = "Data e horario de chegada.")]
        public DateTime HorarioChegada { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Description = "Kilometragem de saida")]
        public decimal KilometragemSaida => Carro.CarroKilometragem;
        
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Description ="Kilometragem de chegada")]
        public decimal KilometragemChegada { get; set; }

        //[Required]
        public byte[] FotoKilometragem { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Tamanho deve ser menor que 50 caracteres.")]
        public string Destino { get; set; }

        public PortariaStatus PortariaStatus { get; set; }

        [Required]
		[ForeignKey("PessoaId")]
		public virtual Pessoa Pessoa{ get; set; }

        [Required]
        public virtual Carro Carro { get; set; }
    }
}
