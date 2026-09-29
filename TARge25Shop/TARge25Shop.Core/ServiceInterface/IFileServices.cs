using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;

namespace TARge25Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship domain);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);

    }
}
