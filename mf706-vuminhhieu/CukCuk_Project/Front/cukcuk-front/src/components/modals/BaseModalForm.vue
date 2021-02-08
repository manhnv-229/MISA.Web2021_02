<template>
<transition name="component-fade" mode="out-in">
<div class="h-dialog" v-show="visible">
    <div class="h-dialog-background"></div>
         
     <slot></slot>
    
    </div>
    
 
</transition>
  
</template>

<script>

export default {
  data() {
    return {
      visible: false,     
    };
  },
 
  methods: {
    hide: async function() {
     
      this.visible = false;
    },
    show: async function() {       
      this.visible = true;     
    },

   
  },
};
</script>

<style src="./modal.scss" lang="scss" />
<style scoped>


.component-fade-enter-active {
  transition: all .3s ease-in-out;
}
.component-fade-leave-active {
  transition: all .3s ease-in-out;
}
.component-fade-enter, .component-fade-leave-to
/* Trước 2.1.8 thì dùng .slide-fade-leave-active */ {
  transform: translatey(-15px);
  opacity: 0;
}
</style>