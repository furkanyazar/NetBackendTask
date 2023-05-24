using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IRefreshTokenService
{
    public Task<RefreshToken> AddAsync(RefreshToken refreshToken);
    public Task DeleteOldsAsync(int userId);
    public Task<RefreshToken?> GetByTokenAsync(string token);
    public Task RevokeDescendantsAsync(RefreshToken refreshToken, string ipAddress, string reason);
    public Task RevokeAsync(
        RefreshToken refreshToken,
        string ipAddress,
        string? reason = null,
        string? replacedByToken = null
    );
    public Task<RefreshToken> RotateAsync(User user, RefreshToken refreshToken, string ipAddress);
}
