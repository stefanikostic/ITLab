using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class FriendController : Controller
    {
        public FriendContext _context = new FriendContext();

        public FriendController()
        {
            _context = new FriendContext();
        }

        // GET: Friend
        public ActionResult Index()
        {
            return RedirectToAction("AllFriends");
        }

        public ActionResult AllFriends()
        {
            return View(_context.allfriends.ToList());
        }
        public ActionResult EditFriend(int id)
        {
            var editFriend = _context.allfriends.Find(id); 
            return View(editFriend);
        }
        [HttpPost]
        public ActionResult EditFriend(FriendModel EditFriend)
        {
            if (!ModelState.IsValid)
            {
                return View("EditFriend", EditFriend);
            }
            var update = _context.allfriends.ToList().Single(i => i.Id == EditFriend.Id);
            update.Ime = EditFriend.Ime;
            update.Id = EditFriend.Id;
            update.MestoZiveenje = EditFriend.MestoZiveenje;
            _context.SaveChanges();
            return View("AllFriends", _context.allfriends.ToList());
        }
        public ActionResult AddFriend()
        {
            FriendModel fr = new FriendModel();
            return View(fr);
        }
        [HttpPost]
        public ActionResult AddFriend(FriendModel newFriend)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFriend", newFriend);
            }
            _context.allfriends.Add(newFriend);
            _context.SaveChanges();
            return View("AllFriends", _context.allfriends.ToList());
        }
        [HttpGet]
        public ActionResult DeleteFriend(int id)
        {
            _context.allfriends.Remove(_context.allfriends.Find(id));
            _context.SaveChanges();
            return RedirectToAction("AllFriends", _context.allfriends.ToList());
        }
    }
}