// TODO: add models method
using COMP003B.Lecture5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Lecture5.Controllers
{
    // api/vehicles
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        // TODO: create an in-memory list of vehicles
        private List<Vehicle> _vehicles = new List<Vehicle>();

        // TODO: add default constructor to pre-fill
        public VehicleController()
        {
            _vehicles.Add(new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2018});
            _vehicles.Add(new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 });
            _vehicles.Add(new Vehicle { Id = 3, Make = "Ford", Model = "Fusion", Year = 2020 });
        }

        // TODO: create CRUD operations

        // TODO: GET ALL (Read): Api/Vehicles
        public ActionResult<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return _vehicles;
        }

        // TODO: GET by id (Read): api/Vehicles/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id) 
        { 
            var vehicle = _vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // TODO: POST (Create): api/Vehicles
        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle) 
        {
            vehicle.Id = _vehicles.Max(x => x.Id) + 1;

            _vehicles.Add(vehicle);

            return CreatedAtAction(nameof(GetVehicleById), new { Id = vehicle.Id }, vehicle);
        }

        // TODO: PUT (Update): api/Vehicles/5

        [HttpPut]
        public ActionResult<Vehicle> UpdateVehicle(int id, Vehicle updatevehicle)
        {
            var vehicle = _vehicles.Find(v => v.Id == id);

            if (vehicle == null)
            {
                return BadRequest();
            }
            // TODO: update the vehicle
            vehicle.Make = updatevehicle.Make;
            vehicle.Model = updatevehicle.Model;
            vehicle.Year = updatevehicle.Year;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteVehicle(int id)
        {
            var vehicle = _vehicles.Find(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            _vehicles.Remove(vehicle);

            return NoContent();

        }

    }
}
