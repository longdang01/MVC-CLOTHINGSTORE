using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class ClientBUS : IClientBUS
    {
        CustomerDAO customerDAO = new CustomerDAO();
        CustomerInfoDAO customerInfoDAO = new CustomerInfoDAO();

        public Customer Login(string username, string password)
        {
            return customerDAO.Login(username, password);
        }
        public void Register(Customer customer)
        {
            customer.info.customer_info_id = GenerateCustomerId();
            customer.customer_id = GenerateCustomerId();

            customerDAO.Register(customer);
        }
        public string GenerateCustomerId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "C" + number;
            List<Customer> list = GetCustomers();
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].customer_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "C" + number;
                }
            }
            return id;
        }
        public string GenerateCustomerInfoId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "CI" + number;
            List<CustomerInfo> list = GetCustomerInfos();
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].customer_info_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "CI" + number;
                }
            }
            return id;
        }
        public List<Customer> GetCustomers()
        {
            return customerDAO.GetCustomers();
        }
        public List<CustomerInfo> GetCustomerInfos()
        {
            return customerInfoDAO.GetCustomerInfos();
        }
    }
}
