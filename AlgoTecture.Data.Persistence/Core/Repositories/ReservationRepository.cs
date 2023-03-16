﻿using System.Diagnostics.CodeAnalysis;
using AlgoTecture.Data.Persistence.Core.Interfaces;
using AlgoTecture.Data.Persistence.Ef;
using AlgoTecture.Domain.Enum;
using AlgoTecture.Domain.Models.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AlgoTecture.Data.Persistence.Core.Repositories;

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }

    [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
    public async Task<Reservation?> CheckReservation(long spaceId, string subSpaceId, DateTime reservationFrom, DateTime reservationTo)
    {
        var query = dbSet.AsQueryable();
        if (!string.IsNullOrEmpty(subSpaceId))
        {
            query.Where(x => x.SubSpaceId == subSpaceId);
        }
        else
        {
            query.Where(x => x.SpaceId == spaceId);
        }
        query.Where(x => x.ReservationStatus != ((ReservationStatusType)3).ToString());
        query.Where(x => x.ReservationFrom <= reservationTo && x.ReservationTo >= reservationFrom);

        var result =  await query.ToListAsync();

        return result.SingleOrDefault();
    }
    
    public override async Task<IEnumerable<Reservation>> All()
    {
        try
        {
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(ReservationRepository));
            return new List<Reservation>();
        }
    }

    public override async Task<Reservation> Upsert(Reservation entity)
    {
        try
        {
            var existingReservation = await dbSet.FirstOrDefaultAsync(x=>x.Id == entity.Id);

            if (existingReservation == null)
                return await Add(entity);

            existingReservation.ReservationFrom = entity.ReservationFrom;
            existingReservation.ReservationTo = entity.ReservationTo;
            existingReservation.ReservationStatus = entity.ReservationStatus;
            existingReservation.TotalPrice = entity.TotalPrice;
            
            return existingReservation;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ReservationRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(long id)
    {
        try
        {
            var exist = await dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (exist == null) return false;

            dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(ReservationRepository));
            return false;
        }
    }
}