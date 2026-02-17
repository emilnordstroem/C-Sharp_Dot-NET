using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lektion_7_HTML_Helpers.Infrastructure
{
	public class Utilities
	{
		public static void SortSelectedList(List<SelectListItem> selectList, string selectedCode)
		{
			ArrayList textList = new ArrayList();
			ArrayList valueList = new ArrayList();
			foreach (SelectListItem li in selectList)
			{
				textList.Add(li.Text);
			}
			textList.Sort();
			foreach (object item in textList)
			{
				SelectListItem li = selectList.Find(x => x.Text.Contains(item.ToString()));
				valueList.Add(li.Value);
			}
			selectList.Clear();
			for (int i = 0; i < textList.Count; i++)
			{
				if (valueList[i].ToString() == selectedCode)
				{
					selectList.Add(new SelectListItem
					{
						Text = textList[i].ToString(),
						Value = valueList[i].ToString(),
						Selected = true
					});
				}
				else
				{
					selectList.Add(new SelectListItem
					{
						Text = textList[i].ToString(),
						Value = valueList[i].ToString()
					});
				}
			}
		}

	}
}
