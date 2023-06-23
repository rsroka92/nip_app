using NIP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.Repositories
{
    public class SubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveToDb(SubjectViewModel model)
        {
            try
            {
                _context.subject.Add(model);
                await _context.SaveChangesAsync();
                if (model.accountNumbers.Count > 0)
                {
                    foreach (var item in model.accountNumbers)
                    {
                        _context.accountnumber.Add(new Models.AccountNumber() { number = item, subjectnip = model.nip });
                    }
                }
                if (model.representatives.Count > 0)
                {
                    model.representatives.ForEach(x => x.subjectnip = model.nip);
                    _context.representative.AddRange(model.representatives);
                }
                if (model.partners.Count > 0)
                {
                    model.partners.ForEach(x => x.subjectnip = model.nip);
                    _context.partner.AddRange(model.partners);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
