using DesafioBaltaIO.Domain.IBGE.Interfaces;
using DesafioBaltaIO.Domain.IBGE.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class IbgeCommandHandler : CommandHandler,
                                      IRequestHandler<CadastrarLocalidadeCommand, ValidationResult>,
                                      IRequestHandler<AlterarCidadeLocalidadeCommand, ValidationResult>,
                                      IRequestHandler<AlterarCodigoLocalidadeCommand, ValidationResult>,
                                      IRequestHandler<AlterarEstadoLocalidadeCommand, ValidationResult>,
                                      IRequestHandler<RemoverLocalidadeCommand, ValidationResult>
    {
        private readonly ILocalidadeReository _localidadeReporitory;

        public IbgeCommandHandler(ILocalidadeReository localidadeReporitory)
        {
            _localidadeReporitory = localidadeReporitory;
        }

        public async Task<ValidationResult> Handle(CadastrarLocalidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var localidade = new LocalidadeModel(message.Codigo, message.Estado, message.Cidade);

            if(!localidade.IsValid())
            {
                AddError("Erro de processamento");
                return ValidationResult;
            }

            await _localidadeReporitory.CadastrarLocalidadeAsync(localidade);

            //Adicionar o evendo de associacao do cadastrante

            return await Commit(_localidadeReporitory.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarCidadeLocalidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var localidadeExistente = await _localidadeReporitory.ObterLocalidadePorCodigoAsync(message.Codigo);

            if (!localidadeExistente.IsValid())
            {
                AddError($"Localidade {message.Codigo} nao encontrada");
                return ValidationResult;
            }

            if (!localidadeExistente.AlterarCidade(message.Cidade)) 
            {
                AddError("Erro ao alterar cidade da localidade");
                return ValidationResult;
            }

            _localidadeReporitory.AtualizarLocalidade(localidadeExistente);

            return await Commit(_localidadeReporitory.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarCodigoLocalidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var localidadeExistente = await _localidadeReporitory.ObterLocalidadePorCodigoAsync(message.CodigoAtual);

            if (!localidadeExistente.IsValid())
            {
                AddError($"Localidade {message.CodigoAtual} nao encontrada");
                return ValidationResult;
            }

            if (!localidadeExistente.AlterarCodigo(message.CodigoNovo))
            {
                AddError("Erro ao alterar o codigo da localidade");
                return ValidationResult;
            }

            _localidadeReporitory.AtualizarLocalidade(localidadeExistente);

            return await Commit(_localidadeReporitory.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarEstadoLocalidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var localidadeExistente = await _localidadeReporitory.ObterLocalidadePorCodigoAsync(message.Codigo);

            if (!localidadeExistente.IsValid())
            {
                AddError($"Localidade {message.Codigo} nao encontrada");
                return ValidationResult;
            }

            if (!localidadeExistente.AlterarEstado(message.Estado))
            {
                AddError("Erro ao alterar o estado da localidade");
                return ValidationResult;
            }

            _localidadeReporitory.AtualizarLocalidade(localidadeExistente);

            return await Commit(_localidadeReporitory.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverLocalidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var localidadeExistente = await _localidadeReporitory.ObterLocalidadePorCodigoAsync(message.Codigo);

            if (!localidadeExistente.IsValid())
            {
                AddError($"Localidade {message.Codigo} nao encontrada");
                return ValidationResult;
            }

            _localidadeReporitory.RemoverLocalidade(localidadeExistente);

            return await Commit(_localidadeReporitory.UnitOfWork);
        }
    }
}
