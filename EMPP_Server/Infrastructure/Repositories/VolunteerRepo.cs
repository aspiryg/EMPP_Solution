using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class VolunteerRepo : IVolunteer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VolunteerRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VolunteerDTO> CreateAsync(VolunteerDTO volunteerDTO)
        {
            var volunteer = _mapper.Map<Volunteer>(volunteerDTO);
            await _context.Volunteers.AddAsync(volunteer);
            await _context.SaveChangesAsync();
            return _mapper.Map<VolunteerDTO>(volunteer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return false;
            }
            _context.Volunteers.Remove(volunteer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VolunteerDTO>> GetAllAsync()
        {
            var volunteers = await _context.Volunteers.ToListAsync();
            if (volunteers == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<VolunteerDTO>>(volunteers);
        }

        public async Task<VolunteerDTO> GetByIdAsync(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return new VolunteerDTO();
            }
            return _mapper.Map<VolunteerDTO>(volunteer);
        }

        public async Task<VolunteerDTO> GetByUserIdAsync(string userId)
        {
            var volunteer = await _context.Volunteers.FirstOrDefaultAsync(v => v.UserId == userId);
            if (volunteer == null)
            {
                return new VolunteerDTO();
            }
            return _mapper.Map<VolunteerDTO>(volunteer);
        }

        public async Task<VolunteerDTO> UpdateAsync(VolunteerDTO volunteerDTO)
        {
            var volunteer = await _context.Volunteers.FindAsync(volunteerDTO.Id);
            if (volunteer == null)
            {
                return new VolunteerDTO();
            }
            _mapper.Map(volunteerDTO, volunteer);
            volunteer.UpdatedDate = DateTime.Now;
            _context.Volunteers.Update(volunteer);
            await _context.SaveChangesAsync();
            return _mapper.Map<VolunteerDTO>(volunteer);
        }
    }
}
