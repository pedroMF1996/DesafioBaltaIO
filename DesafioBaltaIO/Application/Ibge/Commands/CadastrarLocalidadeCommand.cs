﻿using DesafioBaltaIO.Application.Ibge.Commands.Validations;
using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class CadastrarLocalidadeCommand : Command
    {
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        protected CadastrarLocalidadeCommand()
        {}

        public CadastrarLocalidadeCommand(string codigo, string estado, string cidade)
        {
            Codigo = codigo;
            Estado = estado;
            Cidade = cidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarLocalidadeCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}