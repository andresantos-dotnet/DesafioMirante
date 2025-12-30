using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _createDate;

        private bool _active;
        public int Id { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Active
        {

            get { return _active; }

            set
            {
                _active = (value == null ? true : value);
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = (value == null ? DateTime.Now : value); }
        }
    }
}
