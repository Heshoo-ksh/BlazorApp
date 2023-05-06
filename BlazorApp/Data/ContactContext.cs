using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlazorApp.Data
{
    public class ContactContext : DbContext
    {
        /// <summary>
        /// The name of the contacts database, derived from the field name and converted to lowercase.
        /// </summary>
        public static readonly string ContactsDb = nameof(ContactsDb).ToLower();

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)  
        {
            // Log the creation of a new context instance with its unique identifier to the debug output.
            Debug.WriteLine($"{ContextId} context created.");
        }
        /// <summary>
        /// A collection representing a list of contact objects.
        /// </summary>
        public DbSet<Contact>? Contacts { get; set; }

    }
}
