using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class DeliveryMan : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public double Salary { get; protected set; }
        public string PIS { get; protected set; }
        public ICollection<Order> Orders { get; protected set; }

        //Construtores
        public DeliveryMan()
        {
        }

        public DeliveryMan(string name, string pis, double salary)
        {
            this.Name = name?.FormatProps();
            this.PIS = pis?.FormatProps();
            this.Salary = salary;
        }


        //Metodos
        public void Update(string name, double salary)
        {
            this.Name = name?.FormatProps();
            this.Salary = salary;
        }

        public override HashSet<Error> GetErrors()
        {
            return new DeliveryManValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new DeliveryManValidation().CustomValidate(this).Any();
        }
    }
}
