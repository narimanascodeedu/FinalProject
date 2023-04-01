using MediatR;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.ContactInfoModule
{
    public class ContactInfoCreateCommand : IRequest<ContactInfo>
    {
        [Required]
        public string ContactUs { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public class ContactInfoCreateCommandHandler : IRequestHandler<ContactInfoCreateCommand, ContactInfo>
        {
            private readonly MotorOilDbContext db;

            public ContactInfoCreateCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<ContactInfo> Handle(ContactInfoCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new ContactInfo();

                model.ContactUs = request.ContactUs;

                model.PhoneNumber = request.PhoneNumber;

                model.Location = request.Location;

                model.EmailAddress = request.EmailAddress;

                await db.ContactInfos.AddAsync(model, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return model;
            }
        }
    }
}
