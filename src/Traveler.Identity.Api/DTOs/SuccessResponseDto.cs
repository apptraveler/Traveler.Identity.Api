namespace Traveler.Identity.Api.DTOs
{
    public class SuccessResponseDto<T>
    {
        public bool Success { get; }
        public T Data { get; }

        public SuccessResponseDto(T data)
        {
            Success = true;
            Data = data;
        }
    }
}