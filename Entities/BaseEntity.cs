using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IBaseEntity
    {

    }
    public interface IEntityApp : IBaseEntity
    {
    }

    public interface IEntity : IBaseEntity
    {
    }

    public abstract class BaseEntityWithoutPK : IEntity
    {
        public BaseEntityWithoutPK()
        {
        }

        public DateTime CreateDm { get; set; }
        public DateTime? LastUpdateDm { get; set; }
    }

    public abstract class BaseEntity<TKey> : BaseEntityWithoutPK, IEntity
    {
        public BaseEntity()
        {
        }
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
