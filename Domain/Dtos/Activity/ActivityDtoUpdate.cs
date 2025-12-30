using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoUpdate
    {
        private DateTime _createDate;

        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo da tarefa é obrigatório.")]
        [StringLength(150, ErrorMessage = "Titulo deve ter no máximo {1} caracteres.")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Status tarefa é obrigatório.")]
        public short TaskStatus { get; set; }

        [Required(ErrorMessage = "Data de encerramento da tarefa é obrigatório.")]
        public DateTime DueDate { get; set; }
        
    }
}
