using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorApp.Services
{
    public class ContactService
    {
        private IDbContextFactory<ContactContext> dbContextFactory;

        public ContactService (IDbContextFactory <ContactContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        
        public async void AddContact(Contact contact)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Contacts.Add(contact);
                await context.SaveChangesAsync();
            }
            //Navigation.NavigateTo("/");
        }
        
    }
}
