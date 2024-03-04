using System;
using System.Collections.Generic;
using System.Linq;
using GoodsProject.Data;
using GoodsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodsProject.Services
{
    public class BusinessPartnersService
    {
        private readonly ApplicationDbContext _context;

        public BusinessPartnersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (IEnumerable<BusinessPartner> businessPartners, int totalPages) ReadBusinessPartners(string columnName = null, string filterValue = null, int page = 1, int pageSize = 10)
        {
            IQueryable<BusinessPartner> query = _context.BusinessPartner;

            // Apply filtering if columnName and filterValue are provided
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(filterValue))
            {
                query = query.Where(bp => EF.Property<string>(bp, columnName) == filterValue);
            }

            // Calculate total number of pages
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Apply pagination
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            // Execute the query and return results
            IEnumerable<BusinessPartner> businessPartners = query.ToList();
            return (businessPartners, totalPages);
        }
    }
}
