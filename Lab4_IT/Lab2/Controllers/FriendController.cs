using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
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
            return RedirectToAction("listFriends");
        }
        public ActionResult listFriends()
        {
            return View(_context.allfriends.ToList());
        }
        public ActionResult AddFriend()
        {
            FriendModel addfriend = new FriendModel();
            return View(addfriend);
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
            return View("listFriends", _context.allfriends.ToList());
        }
        public ActionResult EditFriend(int id)
        {
            var editfriend = _context.allfriends.Find(id);
            return View(editfriend);
        }
        [HttpPost]
        public ActionResult EditFriend(FriendModel EditFriend)
        {
            if (!ModelState.IsValid)
            {
                return View("EditFriend", EditFriend);
            }
            var novo = _context.allfriends.ToList().Single(i => i.Id == EditFriend.Id);
            novo.Id = EditFriend.Id;
            novo.Ime = EditFriend.Ime;
            novo.MestoZiveenje = EditFriend.MestoZiveenje;
            _context.SaveChanges();
            return View("listFriends", _context.allfriends.ToList());
        }
        [HttpGet]
        public ActionResult DeleteFriend(int id)
        {
            _context.allfriends.Remove(_context.allfriends.Find(id));
            _context.SaveChanges();
            return RedirectToAction("listFriends", _context.allfriends.ToList());
        }
    }
}