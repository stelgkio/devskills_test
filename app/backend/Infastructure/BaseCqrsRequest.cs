using MediatR;

namespace backend.Infastructure
{
    public class BaseCqrsRequest<T> : IRequest<T>
    {
        protected BaseCqrsRequest()
        {

        }


    }
}
