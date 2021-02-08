<template>
  <div>Đây là trang khách hàng</div>
</template>
<script>
export default {
  name: "Customers",
  data() {
    return {
      selectedCustomer: {
        CustomerId: 1,
        FullName: "Nguyễn Văn Mạnh",
      },
      customers: [{ CustomerId: 1, FullName: "Nguyễn Văn Mạnh" }],
    };
  },
};
</script>