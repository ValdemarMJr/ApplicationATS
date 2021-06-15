using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SQLContext _context;

        public AddressRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var address = _context.Adresses.FirstOrDefault(s => s.ID == id);
            if (address is null)
                throw new AddressNotExistsException();
            else
            {
                _context.Adresses.Remove(address);
                _context.SaveChanges();
                return true;
            }
        }

        public Address Get(int id)
        {
            var address = _context.Adresses.FirstOrDefault(s => s.ID == id);
            if (address is null)
                throw new AddressNotExistsException();
            else
            {
                return address;
            }
        }

        public List<Address> GetAll()
        {
            return _context.Adresses.ToList();
        }

        public int Save(Address address)
        {
            int addressID = 0;
            var addressContext = _context.Adresses.FirstOrDefault(a => a.ID == address.ID);

            if (address.ZipCode == null || String.IsNullOrEmpty(address.ZipCode))
                throw new ZipcodeIsRequiredException();
            else if (address.Number == null || String.IsNullOrEmpty(address.Number))
                throw new NumberIsRequiredException();
            else if (address.Street == null || String.IsNullOrEmpty(address.Street))
                throw new StreetIsRequiredException();
            else if (address.NeighborhoodID == null || address.NeighborhoodID <= 0)
                throw new NeighborhoodIsRequiredException();
            else if (address.NeighborhoodID != null || address.NeighborhoodID > 0)
            {
                Neighborhood neighborhood = _context.Neighborhoods.FirstOrDefault(n => n.ID == address.NeighborhoodID);

                if(neighborhood == null || neighborhood.ID <= 0)
                    throw new NeighborhoodIsInvalidException();
            }
            else
            {
                if (addressContext is null)
                {
                    _context.Adresses.Add(address);
                    _context.SaveChanges();

                    addressID = address.ID;
                }
                else
                {
                    addressContext.ZipCode = address.ZipCode;
                    addressContext.Street = address.Street;
                    addressContext.Number = address.Number;
                    addressContext.Complement = address.Complement;
                    addressContext.ReferencePoint = address.ReferencePoint;
                    addressContext.NeighborhoodID = address.NeighborhoodID;
                    _context.SaveChanges();

                    addressID = addressContext.ID;

                }
            }

            return addressID;
        }
    }
}
