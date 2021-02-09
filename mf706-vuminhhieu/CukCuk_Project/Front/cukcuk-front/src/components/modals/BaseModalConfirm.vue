<template>
  <transition name="component-fade" mode="out-in">
    <div class="h-confirm h-container-around-center" v-bind:class="success ? 'h-success' : 'h-fail'"  v-show="visible">
      <div class="h-icon-confirm">
        <i class="fas fa-check fa-2x" v-if="success == true"></i>
        <i class="fas fa-exclamation-circle" v-else></i>
      </div>

      <div class="h-confirm-content">
        <slot></slot>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  props: {
    success: Boolean
  },
  data() {
    return {
      visible: false,
    };
  },

  methods: {
    hide : async function(){
      this.visible = false;
    },
    show: async function () {
      this.visible = true;     
      setTimeout(
        function () {
          this.visible =false;
        }.bind(this), 3000
      );
    },
  },
};
</script>

<style src="./modal.scss" lang="scss" />
<style scoped>
.h-success {
  background-color: seagreen;
}

.h-fail {
  background-color: red;
}

.h-confirm {
  position: fixed;
  right: 10px;
  top: 10px;
  width: 200px;
  height: fit-content;
  min-height: 50px;
  
  color: white;
  z-index: 10000;
  border-radius: 4px;
  box-shadow: inset 0 1px 1px rgb(0 0 0 / 16%), 0 0 20px rgb(102 175 233 / 85%);
}


.h-icon-confirm {
  padding-left: 15px;
  padding-right: 10px;
}

.h-confirm-content {
  padding: 10px;
}

.component-fade-enter-active {
  animation: bounce-in 0.5s ;
}
.component-fade-leave-active {
  animation: bounce-out 2s ;
}
@keyframes bounce-in {
  0% {
    transform: translatey(-25px);
    opacity: 0;
  }

  100% {
    transform: translatex(0px);
    opacity: 1;
  }
}
@keyframes bounce-out {
  100% {
    opacity: 0;
    transform: translatex(0px);
  }
}
</style>