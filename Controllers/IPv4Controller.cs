using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPBag.Models;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPBag.Controllers
{
    public class IPv4Controller : Controller
    {
        private readonly IPContext _context;

        public IPv4Controller(IPContext context)
        {
            _context = context;
        }

        /*
            Show all data from the IPv4 DB table. 
            Teacher (@savonia.fi) can see all data, Students (@edu.savonia.fi) can see available data (available=1)
            Filter + sorting
        */
        public IActionResult Index(IndexModel model, string sortOrder)
        {
            try
            {
                // Dummy user
                var user = "mymail@savonia.fi";
                //var user = User.Identity.Name;

                model.UserSortParm = "user_desc";
                model.DateSortParm1 = "date_desc";
                model.DateSortParm2 = "date2_desc";


                // IPaddress and User filters
                var ipadresses = _context.IpAddresses.ToList();
                if (!string.IsNullOrEmpty(model.IPFilter)) { ipadresses = ipadresses.Where(s => s.IpaddressSeqment.Contains(model.IPFilter)).ToList(); }
                if (!string.IsNullOrEmpty(model.UserFilter)) { ipadresses = ipadresses.Where(s => s.UserEmail.Contains(model.UserFilter)).ToList(); }


                // Table
                var seq = 0;
                var ListIndexIPAddressModel = new List<IndexIPAddressModel>();
                IndexIPAddressModel m = null;
                var lastIPseq = string.Empty;

                foreach (var item in ipadresses)
                {
                    if (seq != item.SeqId)
                    {
                        seq = item.SeqId;
                        if (m != null)
                        {
                            m.IPAddessSegment += lastIPseq;
                            ListIndexIPAddressModel.Add(m);
                        }
                        m = new IndexIPAddressModel()
                        {
                            Id = item.Id,
                            AFrom = item.AFrom.ToString(),
                            ATo = item.ATo.ToString(),
                            IPAddessSegment = item.IpaddressSeqment + " - ",
                            Notes = item.Notes,
                            UserEmail = item.UserEmail
                        };
                    }
                    else
                    {
                        lastIPseq = item.IpaddressSeqment;
                    }
                }
                if (m != null)
                {
                    m.IPAddessSegment += lastIPseq;
                    ListIndexIPAddressModel.Add(m);
                }

                // Sorting
                if (!string.IsNullOrEmpty(sortOrder))
                {
                    if (sortOrder == "user_desc") { sortOrder = "user_asc"; model.UserSortParm = "user_asc"; }
                    else if (sortOrder == "user_asc") { sortOrder = "user_desc"; model.UserSortParm = "user_desc"; }
                    else if (sortOrder == "date_desc") { sortOrder = "date_asc"; model.DateSortParm1 = "date_asc"; }
                    else if (sortOrder == "date_asc") { sortOrder = "date_desc"; model.DateSortParm1 = "date_desc"; }
                    else if (sortOrder == "date2_desc") { sortOrder = "date2_asc"; model.DateSortParm1 = "date2_asc"; }
                    else if (sortOrder == "date2_asc") { sortOrder = "date2_desc"; model.DateSortParm1 = "date2_desc"; }
                }


                // Sorting
                ListIndexIPAddressModel = sortOrder switch
                {
                    "user_asc" => ListIndexIPAddressModel.OrderBy(s => s.UserEmail).ToList(),
                    "user_desc" => ListIndexIPAddressModel.OrderByDescending(s => s.UserEmail).ToList(),

                    "date_asc" => ListIndexIPAddressModel.OrderBy(s => s.AFrom).ToList(),
                    "date_desc" => ListIndexIPAddressModel.OrderByDescending(s => s.AFrom).ToList(),

                    "date2_desc" => ListIndexIPAddressModel.OrderByDescending(s => s.ATo).ToList(),
                    "date2_asc" => ListIndexIPAddressModel.OrderBy(s => s.ATo).ToList(),
                    _ => ListIndexIPAddressModel.OrderBy(s => s.UserEmail).ToList(),
                };


                // To table. If teacher = show all , else show available
                model.Ipaddresses = ListIndexIPAddressModel;
                if (!user.Contains("@savonia.fi")) { model.Ipaddresses = model.Ipaddresses.Where(m => m.UserEmail == user).ToList(); }   return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                model.Ipaddresses = new List<IndexIPAddressModel>();
                return View(model);
            }
        }

        // Show details of specific IPv4 row.
        public IActionResult Details(int? id)
        {
            IPv4Addresses pv4Addresses = _context.IpAddresses.Find(id);
            return PartialView("_DetailsIPv4", pv4Addresses);
        }


        /*  Get a new stack of IPv4 addresses (x5)
            First IPv4-address stack starts from 192.169.000.00 and increase by 1 in each for-loop. 
            192.169.000.250 -> 192.169.001.000
            All data will be set here so user doesn't have to do anything. Users can edit End date and Notes later via Edit component.

            From = now
            To = 3 months from now
            User = current user

            EndDateChecker application will check for rows where To date is ending within 7 days and send email to the user. 
            If the user doesn't update To -date, data will be cleared and other users can get the IP-stack. 
        */
            public async Task<IActionResult> GetIPv4()
        {
            try
            {
                var iPv = _context.IpAddresses.Where(m => m.UserEmail == "").FirstOrDefault();
                if (iPv == null)
                {
                    var last = await _context.IpAddresses.OrderBy(x => x.IpaddressSeqment).LastOrDefaultAsync();
                    if (last == null)
                    {
                        var ip = "192.169.000.00";
                        for (var i = 0; i < 5; i++)
                        {
                            var newip = new IPv4Addresses
                            {
                                IpaddressSeqment = ip + i.ToString(),
                                SeqId = 1,
                                UserEmail = "testi@testi.com",
                                //UserEmail = User.Identity.Name,
                                AFrom = DateTime.Now,
                                ATo = DateTime.Now.AddMonths(3),
                            };
                            _context.IpAddresses.Add(newip);
                        }
                    }
                    else
                    {
                        var seqId = await _context.IpAddresses.MaxAsync(p => p.SeqId);
                        seqId++;
                        var ip = last.IpaddressSeqment;
                        for (var i = 0; i < 5; i++)
                        {
                            var s = ip.Split('.');
                            if (int.Parse(s[3]) < 250)
                            {
                                var seg = int.Parse(s[3]) + 1;
                                s[3] = seg.ToString("000");
                            }
                            else
                            {
                                s[3] = "000";
                                var seg = int.Parse(s[2]) + 1;
                                s[2] = seg.ToString("000");
                            }
                            ip = string.Join(".", s);

                            var newip = new IPv4Addresses
                            {
                                IpaddressSeqment = ip,
                                SeqId = seqId,
                                UserEmail = "testi@testi.com",
                                //UserEmail = User.Identity.Name,
                                AFrom = DateTime.Now,
                                ATo = DateTime.Now.AddMonths(3),
                            };
                            _context.IpAddresses.Add(newip);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                return PartialView("_GetIPv4", null);

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }


        // Edit data of a specific segment(id). Also update Eventlog.
        public IActionResult Edit(int seqId)
        {
            IPv4Addresses pv4Addresses = _context.IpAddresses.Find(seqId);
            return PartialView("_EditIPv4", pv4Addresses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(int seqId, DateTime ATo, string Notes, IPv4Addresses model)
        {
            try
            {
                var data = _context.IpAddresses.Where(f => f.SeqId == seqId).ToList();
                data.ForEach(a => a.ATo = ATo);
                data.ForEach(a => a.Notes = Notes);

                EventsModel eventsModel = new EventsModel()
                {
                    SeqId = model.SeqId,
                    AFrom = model.AFrom,
                    ATo = ATo,
                    UserEmail = model.UserEmail,
                    Notes = Notes,
                    Event = "Edit" + DateTime.Now
                };
                _context.Eventlog.Add(eventsModel);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
