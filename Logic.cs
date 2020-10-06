using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ee3dList
{
    class Logic
    {
        public string ProcessLists(
            bool subsetLeft,
            bool subsetCommon,
            bool subsetRight,
            bool includeUnique,
            bool includeNonUnique,
            bool keepDuplicates,
            string sortType,
            List<string> collectionLeft,
            List<string> collectionRight,
            out List<string> collectionResult)
        {
            collectionResult = new List<string>();
            IEnumerable<string> collectionLeftSubsetUnique = new List<string>();
            IEnumerable<string> collectionLeftSubsetCommon = new List<string>();
            IEnumerable<string> collectionRightSubsetUnique = new List<string>();
            IEnumerable<string> collectionRightSubsetCommon = new List<string>();
            IEnumerable<string> collectionLeftSubsetsChoosed = new List<string>();
            IEnumerable<string> collectionRightSubsetsChoosed = new List<string>();
            IEnumerable<string> collectionResultPre1 = new List<string>();
            IEnumerable<string> collectionResultPre2 = new List<string>();

            // Get subsets for left and right collections
            // (if there is no need to keep duplicates,
            // use Except and Intersect methods due to their better performance).
            if (keepDuplicates)
            {
                collectionLeftSubsetUnique = collectionLeft.Where(x => !collectionRight.Contains(x));
                collectionLeftSubsetCommon = collectionLeft.Where(x => collectionRight.Contains(x));
                collectionRightSubsetUnique = collectionRight.Where(x => !collectionLeft.Contains(x));
                collectionRightSubsetCommon = collectionRight.Where(x => collectionLeft.Contains(x));
            }
            else
            {
                collectionLeftSubsetUnique = collectionLeft.Except(collectionRight);
                collectionLeftSubsetCommon = collectionLeft.Intersect(collectionRight);
                collectionRightSubsetUnique = collectionRight.Except(collectionLeft);
                collectionRightSubsetCommon = collectionRight.Intersect(collectionLeft);
            }

            // Get preliminary left and right collections according to selected subsets
            // (options left/common/right: 001 010 011 100 101 110 111).
            if (!subsetLeft & !subsetCommon & subsetRight)
            {
                collectionLeftSubsetsChoosed = Enumerable.Empty<string>();
                collectionRightSubsetsChoosed = collectionRightSubsetUnique;
            }
            else if (!subsetLeft & subsetCommon & !subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeftSubsetCommon;
                collectionRightSubsetsChoosed = collectionRightSubsetCommon;
            }
            else if (!subsetLeft & subsetCommon & subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeftSubsetCommon;
                collectionRightSubsetsChoosed = collectionRight;
            }
            else if (subsetLeft & !subsetCommon & !subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeftSubsetUnique;
                collectionRightSubsetsChoosed = Enumerable.Empty<string>();
            }
            else if (subsetLeft & !subsetCommon & subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeftSubsetUnique;
                collectionRightSubsetsChoosed = collectionRightSubsetUnique;
            }
            else if (subsetLeft & subsetCommon & !subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeft;
                collectionRightSubsetsChoosed = collectionRightSubsetCommon;
            }
            else if (subsetLeft & subsetCommon & subsetRight)
            {
                collectionLeftSubsetsChoosed = collectionLeft;
                collectionRightSubsetsChoosed = collectionRight;
            }
            else return "Unknown [subsets] combination!";

            // Get sorted preliminary result collection.
            switch (sortType)
            {
                case "[existing - Left, then Right]": collectionResultPre1 =
                    collectionLeftSubsetsChoosed.Concat(collectionRightSubsetsChoosed);
                    break;
                case "[existing - Right, then Left]": collectionResultPre1 =
                    collectionRightSubsetsChoosed.Concat(collectionLeftSubsetsChoosed);
                    break;
                case "[ascending]": collectionResultPre1 =
                    collectionLeftSubsetsChoosed.Concat(collectionRightSubsetsChoosed).OrderBy(x => x);
                    break;
                case "[descending]": collectionResultPre1 =
                    collectionLeftSubsetsChoosed.Concat(collectionRightSubsetsChoosed).OrderByDescending(x => x);
                    break;
                case "[random]": collectionResultPre1 =
                    collectionLeftSubsetsChoosed.Concat(collectionRightSubsetsChoosed).OrderBy(x => Guid.NewGuid());
                    break;
                
                default: return "Unknown [sort] string!";
            }

            // Leave unique and/or non-unique lines, while keeping/not keeping duplicates
            // (options unique/non-unique/keep duplicates: 010 011 10x 110 111).
            if (!includeUnique & includeNonUnique & !keepDuplicates)
            {
                collectionResultPre2 = collectionResultPre1.GroupBy(x => x)
                                                           .Where(x => x.Count() > 1)
                                                           .Select(x => x.Key);
            }
            else if (!includeUnique & includeNonUnique & keepDuplicates)
            {
                IEnumerable<string> temp = new List<string>();
                temp = collectionResultPre1.GroupBy(x => x)
                                           .Where(x => x.Count() > 1)
                                           .Select(x => x.Key);
                collectionResultPre2 = collectionResultPre1.Where(x => temp.Contains(x));
            }
            else if (includeUnique & !includeNonUnique)
            {
                collectionResultPre2 = collectionResultPre1.GroupBy(x => x)
                                                           .Where(x => x.Count() == 1)
                                                           .Select(x => x.Key);
            }
            else if (includeUnique & includeNonUnique & !keepDuplicates)
            {
                collectionResultPre2 = collectionResultPre1.Distinct();
            }
            else if (includeUnique & includeNonUnique & keepDuplicates)
            {
                collectionResultPre2 = collectionResultPre1;
            }
            else return "Unknown [include] combination!";

            collectionResult = collectionResultPre2.ToList();
            return "success";
        }
    }
}
