<template>
<BaseModalConfirm ref="BaseModalConfirm_ref" :success="success">
  <p>{{message}}</p>
</BaseModalConfirm>
</template>

<script>
 import BaseModalConfirm from "../BaseModalConfirm.vue"
export default {
  props: {
    
    message : String,
    success : Boolean
    },
  data() {
    return {
      visible: true,     
    };
  },
 components: {
   BaseModalConfirm
 },
 created(){
    console.log(this.successConfirm);
 },
  methods: {
    hide: async function() {
     
      await this.$refs.BaseModalConfirm_ref.hide();
    },
    show: async function() {       
        await this.$refs.BaseModalConfirm_ref.show(); 
    },

   
  },
};
</script>

<style src="../modal.scss" lang="scss" />
