using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Domain.Enums;

namespace Domain.Dtos.Activity
{
    public class ActivityDto
    {
        [Required (ErrorMessage = "Título da tarefa é obrigatório")]
        [StringLength (150, ErrorMessage = "Titulo deve ter no máximo {1} caracteres")]
        public string Title { get; set; }

        [StringLength (250, ErrorMessage = "Titulo deve ter no máximo {1} caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Status da tarefa é obrigatório")]
        public short TaskStatus { get; set; }

        [Required(ErrorMessage = "Data de encerramento da tarefa é obrigatório")]
        public DateTime DueDate { get; set; }
        public string TaskStatusString => ((TaskStatusEnum)TaskStatus).ToString();
    }

   

}
