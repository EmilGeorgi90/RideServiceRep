using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IEntitiesInterface : IEquatable<IEntitiesInterface>, IComparable<IEntitiesInterface>, INotifyPropertyChanged
    {
        int Id { get; set; }
    }
}
