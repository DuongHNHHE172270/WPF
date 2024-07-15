using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessObjects
{
	public class InputObject
	{
		private readonly InputDao inputDao;

		public InputObject()
		{
			inputDao = new InputDao();
		}

		public void AddInput(InputInfo inputInfo)
		{
			inputDao.AddInput(inputInfo);
		}

		public List<InputInfoViewModel> GetAll() => inputDao.GetAll();

		public bool IsIdInputExists(string idInput) => inputDao.IsIdInputExists(idInput);

		public bool IsIdObjectExists(string idObject) => inputDao.IsIdObjectExists(idObject);

	}
}
