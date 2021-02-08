<template>
  <BaseModalForm ref="BaseForm_ref">
  <div class="h-dialog-content content-delete">
        <div class="warning-text">
          <h2 style="color: red">
            Cảnh báo có {{ listId.length }} nhân viên được chọn !
          </h2>
          <p style="font-size: 16px; padding: 16px">
            Bạn có chắc muốn Xóa thông tin nhân viên này không ?
          </p>
        </div>
        <div class="warning-btn">
          <button class="h-btn h-cancel-btn" id="btnCancel2" @click="hide()">
            Hủy
          </button>
          <button class="h-btn h-save-btn" id="btnOk" @click="Confirm()">
            Có
          </button>   
        </div>     
  </div>
  </BaseModalForm>
</template>

<script>
import * as axios from "axios";
import BaseModalForm from "../BaseModalForm.vue"

export default {
  props: {
    listId: Array,
  },
  data() {
    return {
     
    };
  },
  components:{
    BaseModalForm
  },
  methods: {
     hide: async function() {
       await this.$refs.BaseForm_ref.hide();
    },
    show: async function() {
      await this.$refs.BaseForm_ref.show();
    },

    Confirm: async function() {
      var confirm = [];
      console.log(this.employee);
      this.listId.forEach(async function (item) {
        console.log("id: " + item);
        await axios
          .delete("http://api.manhnv.net/api/employees", item)
          .then(function (res) {
            console.log("success: " + res);
            confirm.push({ id: item, state: true });
          })
          .catch(function (err) {
            console.log("false: " + err);
            confirm.push({ id: item, state: false });
          });

        this.$emit("deleted", confirm);
      });
    },
  },
};
</script>

<style src="../modal.scss" lang="scss" />
