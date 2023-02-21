using checklist_api.Data;
using checklist_api.General;
using checklist_api.Models;

namespace checklist_api.Repository
{
    public class CheckList
    {
        private DataContext _context { get; }

        public CheckList(DataContext context)
        {
            _context = context;
        }

        public GeneralResult GetAll()
        {
            var result = new GeneralResult();

            try
            {
                result.data = _context.CheckListDMs?.Where(x => x.status == Constants.Status.active);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }


            return result;
        }

        public CheckListDM Get(int id) => _context.CheckListDMs?.SingleOrDefault(x => x.id == id);

        public GeneralResult Save(CheckListDM item)
        {
            var result = new GeneralResult();

            try
            {
                if (item.id > 0)
                    _context.CheckListDMs.Update(item);
                else
                    _context.CheckListDMs.Add(item);

                _context.SaveChanges();

                result.data = item;
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Add(string name)
        {
            var result = new GeneralResult();
            var item = new CheckListDM();

            try
            {
                item.name = name;
                item.done = Constants.Done.notdone;
                item.status = Constants.Status.active;
                result = Save(item);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult CheckItem(int id)
        {
            var result = new GeneralResult();
            CheckListDM item = null;

            try
            {
                item = Get(id);

                if (item != null)
                {
                    item.done = item.done == Constants.Done.done ? Constants.Done.notdone : Constants.Done.done;
                    result = Save(item);
                }
                else
                    result.AddError(Messages.Errors.generic);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult ChangeStatus(int id)
        {
            var result = new GeneralResult();
            CheckListDM item = null;

            try
            {
                item = Get(id);

                if (item != null)
                {
                    item.status = Constants.Status.inactive;
                    result = Save(item);
                }
                else
                    result.AddError(Messages.Errors.generic);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
