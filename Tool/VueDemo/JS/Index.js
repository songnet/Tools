//声明式渲染
//      响应式
var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!'
    }
})
//      指令：v-bind、
var app2 = new Vue({
    el: '#app-2',
    data: {
        message: '页面加载于 ' + new Date().toLocaleString()
    }
})
//条件与循环
//v-if
var app3 = new Vue({
    el: '#app-3',
    data: {
        seen: true
    }
})
//v-for
// 向集合内添加新元素：app4.todos.push({ text: '新项目' })
var app4 = new Vue({
    el: '#app-4',
    data: {
        todos: [
          { text: '我' },
          { text: '爱' },
          { text: '学习' }
        ]
    }
})
//处理用户输入
//v-on
var app5 = new Vue({
    el: '#app-5',
    data: {
        message: 'Hello Vue.js!'
    },
    methods: {
        reverseMessage: function () {
            this.message = this.message.split('').reverse().join('')
        }
    }
})
//v-model 他能轻松实现表单输入和应用状态之间的双向绑定
var app6 = new Vue({
    el: '#app-6',
    data: {
        message: 'Hello Vue!'
    }
})
//组件化应用构建
Vue.component('todo-item', {
    props: ['todo'],
    template: '<li>{{ todo.text }}</li>'
})

var app7 = new Vue({
    el: '#app-7',
    data: {
        groceryList: [
          { id: 0, text: '蔬菜' },
          { id: 1, text: '奶酪' },
          { id: 2, text: '随便其他什么人吃的东西' }
        ]
    }
})