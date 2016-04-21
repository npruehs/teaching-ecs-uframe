// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace ECSDemo {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    
    
    #region 
static
    public class FightModuleExtensions {
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<HealthComponent> HealthComponentManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<HealthComponent>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<AttackComponent> AttackComponentManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<AttackComponent>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<TargetComponent> TargetComponentManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<TargetComponent>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<ArmorComponent> ArmorComponentManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<ArmorComponent>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<DefendingEntity> DefendingEntityManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<DefendingEntity>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<AttackingEntity> AttackingEntityManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<AttackingEntity>();
        }
        #endregion
        
        #region 
static
        public List<HealthComponent> HealthComponentComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<HealthComponent>().Components;
        }
        #endregion
        
        #region 
static
        public List<AttackComponent> AttackComponentComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<AttackComponent>().Components;
        }
        #endregion
        
        #region 
static
        public List<TargetComponent> TargetComponentComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<TargetComponent>().Components;
        }
        #endregion
        
        #region 
static
        public List<ArmorComponent> ArmorComponentComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<ArmorComponent>().Components;
        }
        #endregion
        
        #region 
static
        public List<DefendingEntity> DefendingEntityComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<DefendingEntity>().Components;
        }
        #endregion
        
        #region 
static
        public List<AttackingEntity> AttackingEntityComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<AttackingEntity>().Components;
        }
        #endregion
    }
    #endregion
}
