using MediatR;

namespace ScrollsTracker.Application.Commands
{
    public class ProcurarECadastrarObraCommand : IRequest<int>
    {
		public string Titulo { get; set; }
	}
}
