// Service
using System;
using System.Collections.Generic;
using System.Linq;
using GoodsProject.Data;
using GoodsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodsProject.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (IEnumerable<Item> items, int totalPages) ReadItems(string columnName = null, string filterValue = null, int page = 1, int pageSize = 10)
        {
            IQueryable<Item> query = _context.Item; // Corrected the table name to Items

            // Apply filtering if columnName and filterValue are provided
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(filterValue))
            {
                query = query.Where(item => EF.Property<string>(item, columnName) == filterValue);
            }

            // Calculate total number of pages
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Apply pagination
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            // Execute the query and return results
            IEnumerable<Item> items = query.ToList();
            return (items, totalPages);
        }
    }
}
