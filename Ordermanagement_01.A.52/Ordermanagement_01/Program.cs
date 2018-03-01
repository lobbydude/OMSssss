using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ordermanagement_01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //  Application.Run(new Ordermanagement_01.Client_Proposal.Client_Proposal_Email(1));


           //Application.Run(new Ordermanagement_01.Employee.Emp_Matrix("demo",1));

          //  Application.Run(new Ordermanagement_01.Client_Proposal.Client_Proposal_Auto_Send());


     Application.Run(new Ordermanagement_01.Gen_Forms.Login());
    // Application.Run(new Ordermanagement_01.Reports.Reports_Master(1,"2"));
        //    Application.Run(new Ordermanagement_01.Invoice.Invoice_Orders_List(1,"1"));

     //  Application.Run(new Ordermanagement_01.Masters.Client_Order_Cost(1));

           // Application.Run(new Ordermanagement_01.Holiday(1,"demo"));

            //Application.Run(new Ordermanagement_01.Employee.Cleint_Wise_Effeciency("demo",1));

         //   Application.Run(new Ordermanagement_01.Holiday(1,"demo"));


//            Application.Run(new Ordermanagement_01.Employee.fff());


//Application.Run(new Ordermanagement_01.Tax.Tax_Order_Violation_Entry());
//Application.Run(new Ordermanagement_01.Employee.PXT_File_Form_Entry());

//Application.Run(new Ordermanagement_01.Order_Reallocate(1,"1"));

//Application.Run(new Ordermanagement_01.Matrix.Employee_Efficiency_Matrix(1));

           // Application.Run(new Ordermanagement_01.Employee.Break_Details(1));

            //Application.Run(new Ordermanagement_01.Abstractor.Abstractor_State_County_Details("niranjan","1",1));

 //Application.Run(new Ordermanagement_01.Vendors.Vendor_Report());
          //  Application.Run(new Ordermanagement_01.Masters.County_Movement());
 //  Application.Run(new Orderanagement_01.AdminDashboard("1",38",""));
  // Application.Run(new Ordermanagement_01.Abstractor.Abstractor_Order_Que(1,"1"));

      //Application.Run(new Ordermanagement_01.Vendors.Vendor_State_County(6,1,"Nirnajna"));

             // Application.Run(new Ordermanagement_01.Vendors.Vendor_View(1));
          // Application.Run(new Ordermanagement_01.Matrix.Employee_Efficiency_Matrix(1));
           //Application.Run(new Ordermanagement_01.Client_Proposal.Client_Proposal_Email(1));

        

           //Application.Run(new Ordermanagement_01.Client_Proposal.Client_Proposal_Auto_Send());

          //Application.Run(new Ordermanagement_01.Client_Proposal.Client_Proposal_Auto_Send());

          //  Application.Run(new Ordermanagement_01.WordCopyPaste());

        }
        
    }
}
