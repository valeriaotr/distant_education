using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Commands;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.CommandHandlers;

public class DeleteUserInfoCommandHandler : IRequestHandler<DeleteUserInfoCommand>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public DeleteUserInfoCommandHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
    {
        await _tariffUserInfoRepository.DeleteInfo(request.InfoId);
    }
}