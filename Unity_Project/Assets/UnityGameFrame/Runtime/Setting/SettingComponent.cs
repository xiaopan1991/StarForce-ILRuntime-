﻿using GameFramework;
using GameFramework.Setting;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFrame.Runtime
{
    /// <summary>
    /// 配置组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Setting")]
    public sealed class SettingComponent : GameFrameworkComponent
    {
        private ISettingManager m_SettingManager = null;

        [SerializeField]
        private string m_SettingHelperTypeName = "UnityGameFrame.Runtime.DefaultSettingHelper";

        [SerializeField]
        private SettingHelperBase m_CustomSettingHelper = null; //自定义设置辅助器


        protected override void Awake()
        {
            base.Awake();
            //设置管理器
            m_SettingManager = GameFrameworkEntry.GetModule<ISettingManager>();
            if (m_SettingManager == null)
            {
                Log.Fatal("[SettingComponent.Awake] Setting manager is invalid.");
                return;
            }
            //设置辅助器
            SettingHelperBase settingHelper = Helper.CreateHelper(m_SettingHelperTypeName, m_CustomSettingHelper);
            if (settingHelper == null)
            {
                Log.Error("[SettingComponent.Awake] Can not create setting helper.");
                return;
            }

            settingHelper.name = "Setting Helper";
            Transform transform = settingHelper.transform;
            transform.SetParent(this.transform);
            transform.localScale = Vector3.one;

            m_SettingManager.SetSettingHelper(settingHelper);   //设置辅助器
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public void Save()
        {
            m_SettingManager.Save();
        }

        /// <summary>
        /// 检查是否存在指定配置项
        /// </summary>
        /// <param name="settingName">要检查配置项的名称</param>
        /// <returns>指定的配置项是否存在</returns>
        public bool HasSetting(string settingName)
        {
            return m_SettingManager.HasSetting(settingName);
        }

        /// <summary>
        /// 移除指定配置项
        /// </summary>
        /// <param name="settingName">要移除配置项的名称</param>
        public void RemoveSetting(string settingName)
        {
            m_SettingManager.RemoveSetting(settingName);
        }

        /// <summary>
        /// 清空所有配置项
        /// </summary>
        public void RemoveAllSettings()
        {
            m_SettingManager.RemoveAllSettings();
        }

        /// <summary>
        /// 从指定配置项中读取布尔值
        /// </summary>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultValue">当指定的配置项不存在时，返回此默认值</param>
        /// <returns>读取的布尔值</returns>
        public bool GetBool(string settingName, bool defaultValue = false)
        {
            return m_SettingManager.GetBool(settingName, defaultValue);
        }

        /// <summary>
        /// 向指定配置项写入布尔值
        /// </summary>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="value">要写入的布尔值</param>
        public void SetBool(string settingName, bool value)
        {
            m_SettingManager.SetBool(settingName, value);
        }

        /// <summary>
        /// 从指定配置项中读取整数值
        /// </summary>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultValue">当指定的配置项不存在时，返回此默认值</param>
        /// <returns>读取的整数值</returns>
        public int GetInt(string settingName, int defaultValue = 0)
        {
            return m_SettingManager.GetInt(settingName, defaultValue);
        }

        /// <summary>
        /// 向指定配置项写入整数值
        /// </summary>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="value">要写入的整数值</param>
        public void SetInt(string settingName, int value)
        {
            m_SettingManager.SetInt(settingName, value);
        }

        /// <summary>
        /// 从指定配置项中读取浮点数值
        /// </summary>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultValue">当指定的配置项不存在时，返回此默认值</param>
        /// <returns>读取的浮点数值</returns>
        public float GetFloat(string settingName, float defaultValue = 0.0f)
        {
            return m_SettingManager.GetFloat(settingName, defaultValue);
        }

        /// <summary>
        /// 向指定配置项写入浮点数值
        /// </summary>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="value">要写入的浮点数值</param>
        public void SetFloat(string settingName, float value)
        {
            m_SettingManager.SetFloat(settingName, value);
        }

        /// <summary>
        /// 从指定配置项中读取字符串值
        /// </summary>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultValue">当指定的配置项不存在时，返回此默认值</param>
        /// <returns>读取的字符串值</returns>
        public string GetString(string settingName, string defaultValue = "")
        {
            return m_SettingManager.GetString(settingName, defaultValue);
        }

        /// <summary>
        /// 向指定配置项写入字符串值
        /// </summary>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="value">要写入的字符串值</param>
        public void SetString(string settingName, string value)
        {
            m_SettingManager.SetString(settingName, value);
        }

        /// <summary>
        /// 从指定配置项中读取对象
        /// </summary>
        /// <typeparam name="T">要读取对象的类型</typeparam>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <returns>读取的对象</returns>
        public T GetObject<T>(string settingName)
        {
            return m_SettingManager.GetObject<T>(settingName);
        }

        /// <summary>
        /// 从指定配置项中读取对象
        /// </summary>
        /// <param name="objectType">要读取对象的类型</param>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <returns></returns>
        public object GetObject(Type objectType, string settingName)
        {
            return m_SettingManager.GetObject(objectType, settingName);
        }

        /// <summary>
        /// 从指定配置项中读取对象
        /// </summary>
        /// <typeparam name="T">要读取对象的类型</typeparam>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultObj">当指定的配置项不存在时，返回此默认对象</param>
        /// <returns>读取的对象</returns>
        public T GetObject<T>(string settingName, T defaultObj)
        {
            return m_SettingManager.GetObject(settingName, defaultObj);
        }

        /// <summary>
        /// 从指定配置项中读取对象
        /// </summary>
        /// <param name="objectType">要读取对象的类型</param>
        /// <param name="settingName">要获取配置项的名称</param>
        /// <param name="defaultObj">当指定的配置项不存在时，返回此默认对象</param>
        /// <returns></returns>
        public object GetObject(Type objectType, string settingName, object defaultObj)
        {
            return m_SettingManager.GetObject(objectType, settingName, defaultObj);
        }

        /// <summary>
        /// 向指定配置项写入对象
        /// </summary>
        /// <typeparam name="T">要写入对象的类型</typeparam>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="obj">要写入的对象</param>
        public void SetObject<T>(string settingName, T obj)
        {
            m_SettingManager.SetObject(settingName, obj);
        }

        /// <summary>
        /// 向指定配置项写入对象
        /// </summary>
        /// <param name="settingName">要写入配置项的名称</param>
        /// <param name="obj">要写入的对象</param>
        public void SetObject(string settingName, object obj)
        {
            m_SettingManager.SetObject(settingName, obj);
        }

    }
}