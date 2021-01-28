<template>
  <div class="dialog-popup" :class="{isDialogPopupHide:isDialogPopupHide}">
      <div class="dialog-modal"></div>
        <div class="dialog-popup-content">
            <div class="dialog-header">
          <div class="dialog-header-titlepopup">Thông báo</div>
          <div class="dialog-header-close" @click="btnCancelPopup">
            <button>x</button>
          </div>
        </div>
            <div class="dialog-body">
                <div id="notify-text">Bạn có chắc muốn xóa nhân viên này</div>

            </div>
            <div class="dialog-footer">
                <button id="btnCancelCf" class="m-btn m-btn-cancel" @click="btnCancelPopup">Hủy</button>
                <button id="btnDeleteCf" class="m-btn m-btn-display" style="display:none;">Xóa</button>
            </div>
        </div>
    
  </div>
</template>

<script>
export default {
    name:'dialog-popup',
    props:{
        isDialogPopupHide:{
            type:Boolean,
            default:true,
        }
    },
    methods:{
        btnCancelPopup(){
            this.$emit('btnCancelPopup');
        }
    }
}
</script>

<style>
.isDialogPopupHide{
    display: none;
}
.dialog-popup-content{
    position: absolute;
        background-color: #ffffff;

        z-index: 110;
        border-radius: 5px;
        width: 380px;
        height:auto;
        top:300px;
        left:500px;
        border: unset;
}
.dialog-header .dialog-header-titlepopup {
            font-size: 15px;
            
            font-weight: bold;
}
.dialog-popup-content .dialog-body{
    padding: 24px 24px 24px;
}
</style>