using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs{
    public class CreateCustomerCommand: Notifiable, ICommand{
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Document{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}

        bool ICommand.Valid(){
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no maximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no maximo 40 caracteres")
                .IsEmail(Email, "Email", "O e-mail e invalido")
                .HasLen(Document, 11, "Document", "CPF invalido")
            );
            return Valid;
        }

    }
}