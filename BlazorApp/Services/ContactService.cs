using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace BlazorApp.Services
{
    public class ContactService
    {
        private IDbContextFactory<ContactContext> dbContextFactory;

        public ContactService (IDbContextFactory <ContactContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        
        public async void CreateContact(Contact contact)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Contacts.Add(contact);
                await context.SaveChangesAsync();
            }
            //Navigation.NavigateTo("/");
        }
        public async Task<Contact> GetContactById(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Contacts.FindAsync(id);
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Contacts.Update(contact);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteContact(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var contact = await context.Contacts.FindAsync(id);
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                }
            }
        }

       

        public async Task<Contact[]> GetAllContacts()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Contacts.ToArrayAsync();
            }
        }
    }
}
