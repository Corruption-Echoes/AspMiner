using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace idleMiner
{
    public partial class mining : System.Web.UI.Page
    {
        string ore = "ore";
        string miners = "miners";
        string timer = "timerProgress";
        string exponent = "divider";
        protected void Page_Load(object sender, EventArgs e)
        {
            //enableAutoPost();//Don't need this with the .click methodology
            if (!IsPostBack)
            {
                Session[ore] = 0;
                Session[miners] = 0;
                Session[timer] = 0;
                Session[exponent] = 16f;
            }
            updateUI();
        }
        public void mineOre(int bonusOre)
        {
            Session[ore] = getSessionData(ore)+bonusOre;
            updateUI();
        }
        public void storeTimerProgress()
        {
            Session[timer] = int.Parse(timerPort.Value);
        }
        public void updateUI()
        {
            automineTimer.Attributes["value"] = getSessionData(timer).ToString();
            oreDisplay.Text = "Ore :" + getSessionData(ore);
            minerDisplay.Text = "Miners :" + getSessionData(miners);
            Purchase.Text = "Buy Miner : " + calculateMinerPrice() + "G";
        }
        public void PurchaseMiner(Object sender, EventArgs e)
        {
            if (getSessionData(ore) >= calculateMinerPrice())
            {
                Session[ore] = getSessionData(ore) - calculateMinerPrice();
                Session[miners] = getSessionData(miners) + 1;
            }
            storeTimerProgress();
            updateUI();
        }
        public void ManualMine(Object sender, EventArgs e)
        {
            storeTimerProgress();
            mineOre(1);
            updateUI();
        }
        public void AutoMine(Object sender, EventArgs e)
        {
            Session[ore] = getSessionData(ore) + getSessionData(miners);
            Session[timer] = 0;
            updateUI();
        }
        public int getSessionData(string field)
        {
            if (Session[field]!= null)
            {
                return (int)Session[field];
            }
            return 0;
        }
        public int calculateMinerPrice()
        {
            int toReturn = (int)Math.Pow(10, 1+(float)getSessionData(miners)/getSessionData(exponent));
            if(toReturn < 10)
            {
                toReturn = 10;
            }
            return toReturn;
        }
        /*public void enableAutoPost()//Deprecated method for allowing javascript to do postbacks
        {// .click method is cleaner
            ClientScript.GetPostBackEventReference(JavaMine, "");
        }*/
    }
}