using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014731.DTOs;
using WAD._00014731.Interfaces;
using WAD._00014731.Models;

namespace WAD._00014731.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAllActivities()
        {
            var activities = await _activityRepository.GetAllAsync();
            var activitiesDto = _mapper.Map<IEnumerable<ActivityDto>>(activities);
            return Ok(activitiesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivityById(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            var activityDto = _mapper.Map<ActivityDto>(activity);
            return Ok(activityDto);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivity(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            await _activityRepository.CreateAsync(activity);
            var newActivityDto = _mapper.Map<ActivityDto>(activity);
            return Ok(activityDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, ActivityDto activityDto)
        {
            if (id != activityDto.Id)
            {
                return BadRequest();
            }

            var activityToUpdate = await _activityRepository.GetByIdAsync(id);
            if (activityToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(activityDto, activityToUpdate);
            await _activityRepository.UpdateAsync(activityToUpdate);

            return Ok(activityDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityRepository.DeleteAsync(id);
            return Ok(id);
        }
    }
}
