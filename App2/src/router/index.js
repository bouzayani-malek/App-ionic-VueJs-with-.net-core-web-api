import { createRouter, createWebHistory } from '@ionic/vue-router';
import Home from '../views/Home.vue'
import Start from'../views/Start.vue';
import Livre from'../views/Livre.vue';
import EditLivre from'../views/EditLivre.vue';
import Ajouter from'../views/Ajouter.vue';
import Etudiant from'../views/Etudiant.vue';
import AjouterEtudiant from"../views/AjouterEtudiant.vue";
import EditEtudiant from "../views/EditEtudiant.vue";
import Empreint from"../views/Empreint.vue";
import Remise from"../views/Remise.vue";
import Detail from "../views/Detail.vue";

const routes = [
  {
    path: '/',
    redirect: '/start'
  },
  {
    path: '/start',
    name: 'Start',
    component: Start
  },
  {
    path: '/home',
    name: 'Home',
    component: Home
  },
  {
    path: '/livre',
    name: 'Livre',
    component: Livre
  },
  {
    path: '/livre/id=:id',
    name: 'EditLivre',
    component: EditLivre
  },
  {
    path: '/ajouter',
    name: 'Ajouter',
    component: Ajouter
  },
  {
    path: '/etudiant',
    name: 'Etudiant',
    component: Etudiant
  },
  {
    path: '/ajouterEtudiant',
    name: 'ajouterEtudiant',
    component: AjouterEtudiant
  },
  {
    path: '/etudiant/id=:id',
    name: 'EditEtudiant',
    component: EditEtudiant
  },
  {
    path: '/empreint',
    name: 'Empreint',
    component: Empreint
  },
  {
    path: '/remise',
    name: 'Remise',
    component: Remise
  },{
    path: '/detailEtudiant/id=:id',
    name: 'Detail',
    component: Detail
  },
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
