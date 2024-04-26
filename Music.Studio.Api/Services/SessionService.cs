using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class SessionService : ISessionService
{
    
    private readonly iSessionRespository _sessionRespository;

    public SessionService(iSessionRespository sessionRespository)
    {
        _sessionRespository = sessionRespository;
    }
    
    public async Task<bool> SessionExist(int idSession)
    {
        var session= await _sessionRespository.GetByIdAsync(idSession);
        return (session != null);
    }

    public async Task<SessionDto> SaveAsync(SessionDto sessionDto)
    {
        var session = new Session
        {
            DateTime = sessionDto.DateTime,
            EstimatedDuration = sessionDto.EstimatedDuration,
            idProject_FK = sessionDto.idProject_FK,
            idEmployee_FK = sessionDto.idEmployee_FK
        };
        session = await _sessionRespository.SaveAsync(session);
        sessionDto.idSession = sessionDto.idSession;
        return sessionDto;
    }

    public async Task<SessionDto> UpdateAsync(SessionDto sessionDto)
    {
        var session = await _sessionRespository.GetByIdAsync(sessionDto.idSession);

        if (session == null)
        {
            throw new Exception("Session not found");
        }

        session.DateTime = sessionDto.DateTime;
        session.EstimatedDuration = sessionDto.EstimatedDuration;
        session.idProject_FK = sessionDto.idProject_FK;
        session.idEmployee_FK = sessionDto.idEmployee_FK;
        session.UpdatedBy = "";
        session.UpdatedDate = DateTime.Now;
        await _sessionRespository.UpdateAsync(session);
        return sessionDto;
    }

    public async Task<List<SessionDto>> GetAllAsync()
    {
        var sessions = await _sessionRespository.GetAllAsync();
        var sessionsDto = sessions.Select(c => new SessionDto(c)).ToList();
        return sessionsDto;
    }

    public async Task<bool> DeleteAsync(int idSession)
    {
        return await _sessionRespository.DeleteAsync(idSession);
    }

    public async Task<SessionDto> GetByIdAsync(int idSession)
    {
        var session = await _sessionRespository.GetByIdAsync(idSession);
        if (session == null)
        {
            throw new Exception("Session not Found");
        }

        var sessionDto = new SessionDto(session);
        return sessionDto;
    }
}