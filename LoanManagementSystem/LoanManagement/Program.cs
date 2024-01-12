using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.dao;
using LoanManagement.entity;


namespace LoanManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine("                                                Loan Management System         ");
            Console.WriteLine("======================================================================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                        Welcome to the Loan Managemnt Console App!       ");
            Console.WriteLine("======================================================================================================================");
            Console.ResetColor();

            ILoanRepository loanRepository = new LoanRepositoryImpl();
            
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nDashboard - Menu");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1. Apply for Loan\n2. Calculate interest\n3. Get Loan Status" +
                "\n4. Calculate EMI\n5. Pay EMI\n6. Get All Loan Details\n7. Get laon details by Id \n8. Register New Customer");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("9. Log Out");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nChoose from 1-9");
                Console.ResetColor();
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Already an existing customer? Yes/No");
                            Console.Write("Answer: ");
                            string ans = Console.ReadLine();

                            if(ans.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                            {
                                Loan loan = new Loan();

                                Console.WriteLine("\nEnter loan details:");

                                Console.Write("Customer ID: ");
                                int customerId = int.Parse(Console.ReadLine());

                                Console.Write("Principal Amount: ");
                                decimal principalAmount = decimal.Parse(Console.ReadLine());

                                Console.Write("Interest Rate: ");
                                decimal interestRate = decimal.Parse(Console.ReadLine());

                                Console.Write("Loan Term (months): ");
                                int loanTerm = int.Parse(Console.ReadLine());

                                Console.Write("Loan Loan ID: ");
                                int loanId = int.Parse(Console.ReadLine());

                                Console.Write("Loan Type (CarLoan/HomeLoan): ");
                                string loanType = Console.ReadLine();

                                loan.CustomerId = customerId;
                                loan.PrincipalAmount = principalAmount;
                                loan.InterestRate = interestRate;
                                loan.LoanTerm = loanTerm;
                                loan.LoanId = loanId;
                                loan.LoanType = loanType;

                                loanRepository.ApplyLoan(loan);
                            }else
                            {
                                Console.WriteLine("\nPlease register first, then apply for loan. Thank You!");
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Loan Id to calculate interest");
                            Console.Write("Loan ID: ");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            decimal interest = Math.Round(loanRepository.CalculateInterest(loanId),2);
                            Console.WriteLine("\nInterest amount for this loan is Rs. {0}", interest);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter LoanId to check loan status");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            loanRepository.LoanStatus(loanId);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter LoanId to calculate EMI");
                            Console.Write("Loan ID: ");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            decimal emi = Math.Round(loanRepository.CalculateEMI(loanId),2);
                            Console.WriteLine("\nEMI per month for this loan is Rs. {0}", emi);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Enter LoanId to pay EMI");
                            Console.Write("Loan ID: ");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter amount u want to pay");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());
                            loanRepository.LoanRepayment(loanId, amount);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;                    
                    case 6:
                        try
                        {
                            List<Loan> loans = new List<Loan>();
                            loans = loanRepository.GetAllLoans();
                            if(loans != null && loans.Count > 0)
                            {
                                foreach(Loan loan in loans)
                                {
                                    Console.WriteLine(loan);
                                    Console.WriteLine();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("Enter LoanId to get loan details");
                            Console.Write("Loan ID: ");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            Loan loan = loanRepository.GetLoanById(loanId);
                            if(loan != null)
                            {
                                Console.WriteLine(loan);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        try
                        {
                            Console.Write("Enter customer ID: ");
                            int CustomerId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter customer name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter email address: ");
                            string emailAddress = Console.ReadLine();

                            Console.Write("Enter phone number: ");
                            string phoneNumber = Console.ReadLine();

                            Console.Write("Enter address: ");
                            string address = Console.ReadLine();

                            Console.Write("Enter credit score: ");
                            int creditScore = Convert.ToInt32(Console.ReadLine());

                            Customer newCustomer = new Customer
                            {
                                CustomerId = CustomerId,
                                Name = name,
                                EmailAddress = emailAddress,
                                PhoneNumber = phoneNumber,
                                Address = address,
                                CreditScore = creditScore
                            };

                            loanRepository.RegisterNewCustomer(newCustomer);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 9:
                        Console.WriteLine("Loggin out...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Option!");
                        break;
                }
            } while (true);
        }
    }
}
