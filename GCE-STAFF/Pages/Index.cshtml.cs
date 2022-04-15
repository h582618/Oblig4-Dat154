using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web_app_customer;
using Web_app_customer.Models;

namespace GCE_STAFF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly Oblig4Context _context;

        [ViewData]
        public List<Reservation> reservations { get; set; }

        [ViewData]
        public List<Room> rooms { get; set; }

        [ViewData]
        public List<Web_app_customer.Models.Task> tasks { get; set; }

        [ViewData]
        public List<User> users { get; set; }

        [ViewData]
        public String employeeType { get; set; } = "";

        [ViewData]
        public int state { get; set; } = -1;

        public IndexModel(ILogger<IndexModel> logger, Oblig4Context context)
        {
            _logger = logger;
            _context = context;

        }

        public async System.Threading.Tasks.Task OnGetAsync()
        {

            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();
        }


        public async Task<ActionResult> OnPostSelectState(String personnel, String state)
        {
            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();
            if (!String.IsNullOrEmpty(state))
            {

                this.state = Int32.Parse(state);

            }
            this.employeeType = personnel;

            return Page();

        }

        public async Task<ActionResult> OnPostChangeState(String viewState, String personnel, String state, String taskId)
        {
            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();

            Web_app_customer.Models.Task task =  tasks.First(x => x.TaskId == Int32.Parse(taskId));
            if (!String.IsNullOrEmpty(state) && task != null)
            {

                task.State = Int32.Parse(state);
                _context.Update<Web_app_customer.Models.Task>(task);
                _context.SaveChanges();

            }

            this.state = Int32.Parse(viewState);
            this.employeeType = personnel;
            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();

            return Page();

        }

        public async Task<ActionResult> OnPostChangeNote(String viewState, String personnel, String note, String taskId)
        {
            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();

            Web_app_customer.Models.Task task = tasks.First(x => x.TaskId == Int32.Parse(taskId));
            if (!String.IsNullOrEmpty(note) && task != null)
            {

                task.Note = note;
                _context.Update<Web_app_customer.Models.Task>(task);
                _context.SaveChanges();

            }

            this.state = Int32.Parse(viewState);
            this.employeeType = personnel;
            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();

            return Page();

        }

        public async Task<ActionResult> OnPostSelectEmployee(String state, String personnel)
        {

            reservations = await _context.reservations.ToListAsync();
            rooms = await _context.rooms.ToListAsync();
            tasks = await _context.tasks.ToListAsync();
            this.state = Int32.Parse(state);
            if (!String.IsNullOrEmpty(personnel))
            {

                employeeType = personnel;


            }

            return Page();
        }
    }
}
