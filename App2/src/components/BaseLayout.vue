<template>
  <ion-header :translucent="true" slot="fixed">
    <ion-toolbar>
      <ion-title>
       i
        
      </ion-title>
      <slot name="slot-2" />
      <slot name="slot-3" />
    </ion-toolbar>
    <slot name="slot-4" />
    </ion-header>
   
</template>
<script>
import { IonHeader, IonTitle, IonToolbar } from "@ionic/vue";
import { cart } from "ionicons/icons";
import { defineComponent } from "vue";

export default defineComponent({
  data() {
    return {
      cart,
      //Shearsh:"ff"
    };
  },
  components: {
    IonTitle,
    IonToolbar,
    IonHeader,
  },
});
</script>

<style>
ion-toolbar {
  --background: #e5c234;
  --border-style: none;
  --opacity: 0.8;
  --color: red;
}
</style>