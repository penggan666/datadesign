using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datadesign
{
    class Student
    {
        public String sid;
        public String sname;
        public String sdept;
        public String ssex;
        public void setStudent(String sid, String sname, String sdept, String ssex)
        {
            this.sid = sid;
            this.sname = sname;
            this.sdept = sdept;
            this.ssex = ssex;
        }
        String[] lngroup = {"赵","钱","孙","李","周","吴","郑","王",
            "冯","陈","褚","卫","蒋","沈","韩","杨","欧阳",
            "朱","秦","尤","许","何","吕","施","张","彭"
            ,"孔","曹","严","华","金","魏","陶","姜","念","东方","慕容"};

        String[] mfngroup = {"刚","坚","毅","韧","豪","英","勇","雄","猛","俊","梓",

            "轩","瑜","霖","","","凌","嘉","晨","斌","宁","维","金",
            "富","永","明","庶","淦","竟","剑","宏","","胜","堃","川","笑","坚",
            "健","泽","江","明","","平","云","骏","飞","帆","峰","火","木","林","志","森","真","忠"};
        String[] ffngroup = {"叶","璐","娅","","晶","妍","瑶","毓","茜",
            "秋","珊","莎","锦","黛","青","","婷","姣","婉","娴","瑾","颖","露",
            "怡","婵","","蓓","纨","仪","荷","丹","蓉","","","琴","蕊","薇",
            "菁","岚","苑","婕","馨","瑗","琰","韵","融","","艺","咏","卿","聪",
            "澜","纯","悦","昭","冰","爽","","茗","羽","希","宁","欣","飘","育",
            "馥","筠","竹","霭","凝","晓","欢","霄","枫","芸",
            "菲","寒","伊","亚","芊","墨","雅","韵","可","柔","芊","墨","雅","韵"};
        String[] college = {"土木建筑工程学院","农学院","生命科学学院"
            ,"林学院","动物科学学院","人文学院","法学院","理学院","外国语学院","经济学院"
            ,"计算机科学学院","管理学院","大数据学院","药学院","化工学院","美术学院","音乐学院"};
        int[] lastnum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<Student> slist = new List<Student>();
        public Dictionary<String, String> strtodic(String[] x)
        {
            Dictionary<String, String> colege = new Dictionary<string, string>();
            int temp = 200;
            foreach (String i in x)
            {
                colege.Add(i, Convert.ToString(temp));
                temp = temp + 10;
            }
            return colege;
        }
        public void GMaleSinfo(string year)
        {
            Random random = new Random();
            int lnindex;
            int fnindex;
            int cindex;
            Dictionary<String, String> temp = strtodic(college);
            for (int i = 0; i < 500; i++)
            {
                lnindex = random.Next(lngroup.Length);
                fnindex = random.Next(mfngroup.Length);
                String name = lngroup[lnindex] + mfngroup[fnindex];
                fnindex = random.Next(mfngroup.Length);
                name = name + mfngroup[fnindex];
                cindex = random.Next(college.Length);
                String sc = college[cindex];
                int num = ++lastnum[cindex];
                String last;
                if (num < 10)
                {
                    last = num.ToString("00#");
                }
                else if (num >= 10 && num < 100)
                {
                    last = num.ToString("0##");
                }
                else
                {
                    last = num.ToString();
                }
                string year1 = year.Substring(2, 2) + "00";
                String id = year1 + temp[college[cindex]] + last;
                Student stu = new Student();
                stu.setStudent(id, name, sc, "男");
                slist.Add(stu);
            }
        }
        public void GFeMaleSinfo(string year)
        {
            Random random = new Random();
            int lnindex;
            int fnindex;
            int cindex;
            Dictionary<String, String> temp = strtodic(college);
            for (int i = 0; i < 500; i++)
            {
                lnindex = random.Next(lngroup.Length);
                fnindex = random.Next(ffngroup.Length);
                String name = lngroup[lnindex] + ffngroup[fnindex];
                fnindex = random.Next(ffngroup.Length);
                name = name + ffngroup[fnindex];
                cindex = random.Next(college.Length);
                String sc = college[cindex];
                int num = ++lastnum[cindex];
                String last;
                if (num < 10)
                {
                    last = num.ToString("00#");
                }
                else if (num >= 10 && num < 100)
                {
                    last = num.ToString("0##");
                }
                else
                {
                    last = num.ToString();
                }
                string year1 = year.Substring(2, 2) + "00";
                String id = year1 + temp[college[cindex]] + last;
                Student stu = new Student();
                stu.setStudent(id, name, sc, "女");
                slist.Add(stu);
            }
        }
        public List<Student> GetStudentList(string year)
        {
            GFeMaleSinfo(year);
            GMaleSinfo(year);
            return slist;
        }
    }
}
