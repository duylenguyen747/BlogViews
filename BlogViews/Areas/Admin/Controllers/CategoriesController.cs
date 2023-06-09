﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogViews.Models;
using BlogViews.Helpper;
using PagedList.Core;

namespace BlogViews.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoriesController : Controller
	{
		private readonly BlogViewsDbContext _context;

		public CategoriesController(BlogViewsDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Categories
		//public async Task<IActionResult> Index()
		//{
		//      return _context.Categories != null ?
		//                  View(await _context.Categories.ToListAsync()) :
		//                  Problem("Entity set 'BlogViewsDbContext.Categories'  is null.");
		//}

		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = Utilities.PAGE_SIZE;
			var lsCategories = _context.Categories
				.OrderByDescending(x => x.CatId);
			PagedList<Category> models = new PagedList<Category>(lsCategories, pageNumber, pageSize);
			ViewBag.CurrentPage = pageNumber;
			return View(models);
		}

		// GET: Admin/Categories/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var category = await _context.Categories
				.FirstOrDefaultAsync(m => m.CatId == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// GET: Admin/Categories/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Categories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CatId,CatName,Title,Alias,MetaDesc,MetaKey,Thumb,Published,Ordering,Parents,Levels,Icon,Cover,Description")] Category category)
		{
			if (ModelState.IsValid)
			{
				_context.Add(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		// GET: Admin/Categories/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var category = await _context.Categories.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		// POST: Admin/Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CatId,CatName,Title,Alias,MetaDesc,MetaKey,Thumb,Published,Ordering,Parents,Levels,Icon,Cover,Description")] Category category)
		{
			if (id != category.CatId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(category);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryExists(category.CatId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		// GET: Admin/Categories/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var category = await _context.Categories
				.FirstOrDefaultAsync(m => m.CatId == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// POST: Admin/Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Categories == null)
			{
				return Problem("Entity set 'BlogViewsDbContext.Categories'  is null.");
			}
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				_context.Categories.Remove(category);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoryExists(int id)
		{
			return (_context.Categories?.Any(e => e.CatId == id)).GetValueOrDefault();
		}
	}
}