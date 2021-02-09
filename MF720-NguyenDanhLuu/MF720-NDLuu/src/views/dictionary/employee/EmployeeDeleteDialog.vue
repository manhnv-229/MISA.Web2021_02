<style scoped>
.isHideDelete{
    display: none;
}
.m-dialog {
    z-index: 999;
}
.m-delete-content{
  position: fixed;
  border-radius: 5px;
  width: 350px;
  height: 156px;
  background-color: #fff;
  left: calc(50% - 150px);
  top: calc(50% - 70px);
  border: 1px solid #000000;
}
.dialog-delete-header {
  position: relative;
  height: 40px;
  line-height: 60px;
  padding-left: 16px;
  display: flex;
  font-size: 24px;
}
.dialog-header-close {
  position: absolute;
  right: 16px;
  width: 24px;
  height: 24px;
  border-radius: 50%;
  cursor: pointer;
  top: 10px;
  align-items: center;
  border: none;
  background-color: transparent;
  font-size: 24px;
  line-height: 24px;
}
.dialog-body {
  margin-top: 10px;
  padding: 0 16px 16px 16px;
  position: relative;
}
.dialog-footer {
  display: flex;
  width: 100%;
  height: 60px;
  background-color: #e9ebee;
  border-radius: 0 0 5px 5px;
  align-items: center;
  justify-content: flex-end;
  padding: 12px 24px;
  box-sizing: border-box;
}
.dialog-body-image{
  width: 30px;
  height: 30px;
  /* background-image: url("/assets/icon/warning.png"); */
  background-color: #e5e5e5;
  border-radius: 50%;
  /* margin-left: 10px; */
}
.dialog-body-text{
  position: absolute;
  top: 5px;
  left: 60px;
}

</style>
<template>
  <div>
    
    <div
      class="m-dialog dialog-detail"
      title="Xác nhận xoá"
      :class="{isHideDelete: isHideDelete }"
    >
      <div class="m-delete-content">
        <div class="dialog-delete-header">
          <div class="dialog-header-title">Xác nhận xoá!</div>
          <div class="dialog-header-close">
            <button @click="btnCancelDeleteOnClick">x</button>
          </div>
        </div>
        <div class="dialog-body">
          <div class="dialog-body-image"><img src="/src/assets/icon/warning.png" alt=""></div>
          <span class="dialog-body-text">Bạn có chắc muốn xoá</span>
        </div>
        <div class="dialog-footer">
          <button id="btnCancel" class="m-btn m-btn-default m-btn-cancel" v-on:click="btnCancelDeleteOnClick">
            Hủy
          </button>
          <button id="btnSave" class="m-btn m-btn-default">
            <i class="far fa-save"></i><span class="btn-text">Lưu</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: ['isHideDelete'],
  methods: {
    btnCancelDeleteOnClick(){
      this.$emit('closeDelete',true);
    }
  },
  data() {
    return {
      dialog: false,
      display: "none",
    };
  },
};
</script>
