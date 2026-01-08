using Domain.Annotations;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoCreate
    {
        private DateTime _createDate;

        [Required(ErrorMessage = "Titulo da tarefa é obrigatório.")]
        [StringLength(150, ErrorMessage = "Titulo deve ter no máximo {1} caracteres.")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Status tarefa é obrigatório.")]
        [EnumValue<TaskStatusEnum>]  // ← valida enum via annotation
        public string TaskStatusString { get; set; }  // ← agora é string!

        [Required(ErrorMessage = "Data de encerramento da tarefa é obrigatório.")]
        [FutureDate] // (se já tiver criado o atributo de data futura)
        public DateTime DueDate { get; set; }

        public DateTime CreateDate
        {
            get => _createDate;
            set => _createDate = value == default ? DateTime.Now : value;
        }
        public short TaskStatus => (short)Enum.Parse<TaskStatusEnum>(TaskStatusString, true);
    }
}
